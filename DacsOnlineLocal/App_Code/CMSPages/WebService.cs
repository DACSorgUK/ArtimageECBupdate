using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DacsOnline.Model.Manager;
using DacsOnline.Model.Dto;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.IO;
using DacsOnline.Model.Utilities;
using System.Linq;

/// <summary>
/// Empty web service template.
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public WebService()
    {
        //Uncomment the following line if using designed components
        //InitializeComponent();
    }

    ///// <summary>
    ///// Returns the data from DB.
    ///// </summary>
    ///// <param name="parameter">String parameter for sql command</param>
    //[WebMethod]
    //public DataSet GetDataSet(string parameter)
    //{
    //    // INSERT YOUR WEB SERVICE CODE AND RETURN THE RESULTING DATASET

    //    return null;
    //}


    //[System.Web.Services.WebMethod(MessageName = "GetCompletionList")]
    //[System.Web.Script.Services.ScriptMethod]
    //public string[] GetCompletionList(string prefixText, int count)
    //{
    //    // INSERT YOUR WEB SERVICE CODE AND RETURN THE RESULTING STRING ARRAY

    //    return null;
    //}


    //[System.Web.Services.WebMethod(MessageName = "GetCompletionListContext")]
    //[System.Web.Script.Services.ScriptMethod]
    //public string[] GetCompletionList(string prefixText, int count, string contextKey)
    //{
    //    // INSERT YOUR WEB SERVICE CODE AND RETURN THE RESULTING STRING ARRAY

    //    return null;
    //}

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<TempAtrist> ArtistSearch(string term)
    {
        SAPApi _sapApi = new SAPApi();
        SearchAllArtistResult _items1 = _sapApi.SearchAllArtistResult(term, term, "Y", "", 1, 15);
        //// SearchAllArtistResult _items2 = _sapApi.SearchAllArtistResult(null, term, "Y","", 1, 10);

        List<TempAtrist> artistList = new List<TempAtrist>();

        if (_items1.TotalArtist != 0)
            foreach (DACSArtist data in _items1.ArtistList.DACSArtistList)
            {
                TempAtrist _data = new TempAtrist();

                if (string.IsNullOrEmpty(data.FirstName) && string.IsNullOrEmpty(data.LastName))
                {
                    string[] artistCardName = data.CardName.Split(' ');
                    if (artistCardName.Length > 0)
                        _data.text = artistCardName[0];
                    if (artistCardName.Length > 1)
                        _data.text += artistCardName[1];

                    _data.id = data.ArtistId;
                }
                else
                {
                    _data.text = data.FirstName + " " + data.LastName;
                    _data.id = data.ArtistId;
                }

                artistList.Add(_data);

                //artistList.Add(
                //new TempAtrist
                //{
                //    text = data.FirstName + " " + data.LastName,
                //    id = data.ArtistId
                //}
                //);
            }

        ////if (_items2.TotalArtist != 0)
        ////    foreach (DACSArtist data in _items2.ArtistList.DACSArtistList)
        ////    {
        ////        TempAtrist _data = new TempAtrist();

        ////        if (string.IsNullOrEmpty(data.FirstName) && string.IsNullOrEmpty(data.LastName))
        ////        {
        ////            string[] artistCardName = data.CardName.Split(' ');
        ////            if (artistCardName.Length > 0)
        ////                _data.text = artistCardName[0];
        ////            if (artistCardName.Length > 1)
        ////                _data.text += artistCardName[1];

        ////            _data.id = data.ArtistId;
        ////        }
        ////        else
        ////        {
        ////            _data.text = data.FirstName + " " + data.LastName;
        ////            _data.id = data.ArtistId;
        ////        }

        ////        var _ArtistExist = artistList.Where(a => a.id == _data.id).SingleOrDefault();

        ////        if (_ArtistExist == null)
        ////            artistList.Add(_data);

        ////        //artistList.Add(
        ////        //new TempAtrist
        ////        //{
        ////        //    text = data.FirstName + " " + data.LastName,
        ////        //    id = data.ArtistId
        ////        //}
        ////        //);
        ////    }

        // INSERT YOUR WEB SERVICE CODE AND RETURN THE RESULTING DATASET
        //JavaScriptSerializer js = new JavaScriptSerializer();
        //return js.Serialize(artistList);
        return artistList;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void Upload()
    {
        int fileSize = 0;

        //////
        HttpFileCollection Files = HttpContext.Current.Request.Files;
        string path = HttpContext.Current.Server.MapPath("~/App_Data/");

        for (int i = 0; i < Files.Count; i++)
        {
            HttpPostedFile File = Files[i];
            fileSize = File.ContentLength;

            string filename = File.FileName;
            string extension = Path.GetExtension(File.FileName);
            string filePrefix = Guid.NewGuid().ToString() + "_";

            //string filename = System.IO.Path.GetFileName(AsyncFileUpload1.FileName);
            string finalFileName = filePrefix + filename;

            if (!Directory.Exists(HttpContext.Current.Server.MapPath(ConstantDataForForms.GLOBAL_TEMP)))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(ConstantDataForForms.GLOBAL_TEMP));
            }

            //AsyncFileUpload1.SaveAs(Server.MapPath(ConstantDataForForms.GLOBAL_TEMP + "/") + finalFileName);
            File.SaveAs(Server.MapPath(ConstantDataForForms.GLOBAL_TEMP + "/") + finalFileName);

            if (Session["SessionKeyCLFileList"] != null)
            {
                var fileList = (List<string>)Session["SessionKeyCLFileList"];
                fileList.Add(finalFileName);
                Session["SessionKeyCLFileList"] = fileList;
            }
            else
            {
                List<string> fileList = new List<string>();
                fileList.Add(finalFileName);
                Session["SessionKeyCLFileList"] = fileList;
            }
            // File.SaveAs(Path.Combine(path, String.Concat(fileName, extension)));
        }

        //JavaScriptSerializer js = new JavaScriptSerializer();
        // return js.Serialize(fileSize); ;// new { FileSize = fileSize };
        // return new { dataz = fileSize };
        // return fileSize ;
    }
}

public class TempAtrist
{
    public string id { get; set; }
    public string text { get; set; }
}

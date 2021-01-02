
public class GooglePhotoJson
{
    public string title { get; set; }
    public string description { get; set; }
    public string imageViews { get; set; }
    public Creationtime creationTime { get; set; }
    public Modificationtime modificationTime { get; set; }
    public Phototakentime photoTakenTime { get; set; }
    public Geodata geoData { get; set; }
    public Geodataexif geoDataExif { get; set; }
    public Googlephotosorigin googlePhotosOrigin { get; set; }
}

public class Creationtime
{
    public string timestamp { get; set; }
    public string formatted { get; set; }
}

public class Modificationtime
{
    public string timestamp { get; set; }
    public string formatted { get; set; }
}

public class Phototakentime
{
    public string timestamp { get; set; }
    public string formatted { get; set; }
}

public class Geodata
{
    public float latitude { get; set; }
    public float longitude { get; set; }
    public float altitude { get; set; }
    public float latitudeSpan { get; set; }
    public float longitudeSpan { get; set; }
}

public class Geodataexif
{
    public float latitude { get; set; }
    public float longitude { get; set; }
    public float altitude { get; set; }
    public float latitudeSpan { get; set; }
    public float longitudeSpan { get; set; }
}

public class Googlephotosorigin
{
    public Webupload webUpload { get; set; }
}

public class Webupload
{
    public Computerupload computerUpload { get; set; }
}

public class Computerupload
{
}

//{
//    "title": "DSCF1562.JPG",
//    "description": "",
//    "imageViews": "0",
//    "creationTime": {
//        "timestamp": "1609513943",
//        "formatted": "Jan 1, 2021, 3:12:23 PM UTC"
//    },
//    "modificationTime": {
//        "timestamp": "1609513956",
//        "formatted": "Jan 1, 2021, 3:12:36 PM UTC"
//    },
//    "photoTakenTime": {
//        "timestamp": "1509478853",
//        "formatted": "Oct 31, 2017, 7:40:53 PM UTC"
//    },
//    "geoData": {
//        "latitude": 0.0,
//        "longitude": 0.0,
//        "altitude": 0.0,
//        "latitudeSpan": 0.0,
//        "longitudeSpan": 0.0
//    },
//    "geoDataExif": {
//        "latitude": 0.0,
//        "longitude": 0.0,
//        "altitude": 0.0,
//        "latitudeSpan": 0.0,
//        "longitudeSpan": 0.0
//    },
//    "googlePhotosOrigin": {
//        "webUpload": {
//            "computerUpload": {
//            }
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;

public class RestHelper
{
    private const string baseAddress = "https://virtserver.swaggerhub.com/duck-rabbit/cdpr_rest_demo/1.0.0";
    private const string acceptValue = "application/json";
    private const int requestTimeout = 120;


    public static UnityWebRequest PrepareGet(string address)
    {
        var fullAddress = baseAddress + address;

        var request = new UnityWebRequest();
        request = new UnityWebRequest(fullAddress, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        request.timeout = requestTimeout;

        return request;
    }

    public static UnityWebRequest PreparePost<T>(string address, T inBody)
    {
        var fullAddress = baseAddress + address;

        var bodyJSON = JsonConvert.SerializeObject(inBody);
        var uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(bodyJSON));
        uploadHandler.contentType = "application/json";

        var downloadHandler = new DownloadHandlerBuffer();
        UnityWebRequest request = new UnityWebRequest(fullAddress, "POST");

        request.uploadHandler = uploadHandler;
        request.downloadHandler = downloadHandler;
        request.timeout = requestTimeout;

        return request;
    }
}

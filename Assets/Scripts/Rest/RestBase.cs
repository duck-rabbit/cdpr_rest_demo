using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using cdprRestDemo.Model;

public class RestBase
{
    public UnityWebRequest WebRequest { get; set; }

    public bool NetworkError { get { return WebRequest.isNetworkError; } }
    public long ResponseCode { get { return WebRequest.responseCode;  } }
    public ErrorResponse ErrorResponse
    {
        get
        {
            string text = WebRequest.downloadHandler.text;
            var errorResponse =  JsonConvert.DeserializeObject<ErrorResponse>(text);
            if (errorResponse == null)
                errorResponse = new ErrorResponse();
            if (errorResponse.Error == null)
                errorResponse.Error = "";
            if (errorResponse.Message == null)
                errorResponse.Message = "";
            return errorResponse;
        }
    }
}

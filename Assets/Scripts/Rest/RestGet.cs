using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class RestGet<T> : RestBase
{
    private T body;
    private bool bodySet = false;

    public void Prepare(string address)
    {
        WebRequest = RestHelper.PrepareGet(address);
    }

    public T GetBody()
    {
        if (!bodySet)
        {
            string jsonString = WebRequest.downloadHandler.text;
            body = JsonConvert.DeserializeObject<T>(jsonString);
            bodySet = true;
        }

        return body;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RestPost : RestBase
{
    public void Prepare<T>(string address, T inBody)
    {
        WebRequest = RestHelper.PreparePost<T>(address, inBody);
    }
}

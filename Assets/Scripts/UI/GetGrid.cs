using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cdprRestDemo.Model;
using Newtonsoft.Json;
using UnityEngine.UI;

public class GetGrid : MonoBehaviour
{
    [SerializeField] private string endpointAddress;
    [SerializeField] private Text stringText;
    [SerializeField] private Text intText;
    [SerializeField] private Text floatText;
    [SerializeField] private Text consoleText;

    public void OnClick()
    {
        StartCoroutine(ClickCoroutine());
    }

    public IEnumerator ClickCoroutine()
    {
        RestGet<TestObject> restGet = new RestGet<TestObject>();
        restGet.Prepare(endpointAddress);

        consoleText.text = "Connecting...";

        yield return restGet.WebRequest.SendWebRequest();

        if (restGet.NetworkError)
        {
            Debug.LogError(string.Format("REST ERROR: Network failure during getting '{0}'", endpointAddress));
            yield break;
        }

        Debug.Log(restGet.GetBody().ToString());

        switch (restGet.ResponseCode)
        {
            case 250L:
                stringText.text = restGet.GetBody().StringProperty;
                intText.text = restGet.GetBody().IntProperty.ToString();
                floatText.text = restGet.GetBody().FloatProperty.ToString();
                consoleText.text = "GET Successfull";
                break;
            default:
                Debug.LogError(string.Format("REST ERROR\n{0}\n{1}", restGet.ErrorResponse.Error, restGet.ErrorResponse.Message));
                consoleText.text = string.Format("Error Code {0}", restGet.ResponseCode);
                break;
        }
    }

    private void OnApplicationQuit()
    {
        StopAllCoroutines();
    }
}

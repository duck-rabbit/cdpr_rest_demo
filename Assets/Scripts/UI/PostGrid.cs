using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cdprRestDemo.Model;
using Newtonsoft.Json;
using UnityEngine.UI;

public class PostGrid : MonoBehaviour
{

    [SerializeField] private string endpointAddress;
    [SerializeField] private InputField stringText;
    [SerializeField] private InputField intText;
    [SerializeField] private InputField floatText;
    [SerializeField] private Text consoleText;

    public void OnClick()
    {
        StartCoroutine(ClickCoroutine());
    }

    public IEnumerator ClickCoroutine()
    {
        RestPost restPost = new RestPost();
        TestObject testObject = new TestObject();
        testObject.StringProperty = stringText.text;
        testObject.StringProperty = intText.text;
        testObject.StringProperty = floatText.text;

        restPost.Prepare(endpointAddress, testObject);

        consoleText.text = "Connecting...";

        yield return restPost.WebRequest.SendWebRequest();

        if (restPost.NetworkError)
        {
            Debug.LogError(string.Format("REST ERROR: Network failure during getting '{0}'", endpointAddress));
            yield break;
        }

        Debug.Log(restPost.WebRequest.downloadHandler.ToString());
        Debug.Log(restPost.ResponseCode);

        switch (restPost.ResponseCode)
        {
            case 250L:
                consoleText.text = "POST Successfull.";
                break;
            default:
                Debug.LogError(string.Format("REST ERROR\n{0}\n{1}", restPost.ErrorResponse.Error, restPost.ErrorResponse.Message));
                consoleText.text = string.Format("Error Code {0}", restPost.ResponseCode);
                break;
        }
    }

    private void OnApplicationQuit()
    {
        StopAllCoroutines();
    }
}

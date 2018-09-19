using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;


public class ServerDataRequest : MonoBehaviour
{


    // http://192.168.42.1:8000/login/admin/123456789

    public string url = "http://10.10.10.103:8000/";
    public string username;
    public string password;

    private bool requestFinished;
    private bool requestErrorOccurred;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Request from " + url + username + "/" + password);
            StartCoroutine(GetRequest(url + username + "/" + password));
        }
    }



    IEnumerator GetRequest(string uri)
    {

        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
}
        /*
        IEnumerator GetRequest(string uri)
        {
            requestFinished = false;
            requestErrorOccurred = false;

            UnityWebRequest request = UnityWebRequest.Get(uri);
            //  yield return request.Send();
            yield return UnityWebRequest.

            requestFinished = true;
            if (request.isError)
            {
                Debug.Log("Something went wrong, and returned error: " + request.error);
                requestErrorOccurred = true;
            }
            else
            {
                // Show results as text
                Debug.Log(request.downloadHandler.text);

                if (request.responseCode == 200)
                {
                    Debug.Log("Request finished successfully!");
                }
                else if (request.responseCode == 401) // an occasional unauthorized error
                {
                    Debug.Log("Error 401: Unauthorized. Resubmitted request!");
                    StartCoroutine(GetRequest(GenerateRequestURL(lastRequestURL, lastRequestParameters)));
                    requestErrorOccurred = true;
                }
                else
                {
                    Debug.Log("Request failed (status:" + request.responseCode + ")");
                    requestErrorOccurred = true;
                }

                if (!requestErrorOccurred)
                {
                    yield return null;
                    // process results
                }
            }
    /*
            IEnumerator UserVerification()
        {
            string login_url = url + username + "/" + password;

            WWWForm form = new WWWForm();

            form.AddField("username", username);
            form.AddField("password", password);

            yield return form.SendWebRequest();
            Debug.Log(login_url);

        }

        */

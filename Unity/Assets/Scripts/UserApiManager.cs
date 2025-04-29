using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Net;

public class UserApiManager : MonoBehaviour
{
    private string baseUrl = "https://192.168.1.105:7029/api/user";

    private void Awake()
    {
        ServicePointManager.ServerCertificateValidationCallback +=
    (sender, certificate, chain, sslPolicyErrors) => true;
    }

    public IEnumerator CreateUser(string name)
    {
        string url = $"{baseUrl}/create";
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes($"\"{name}\"");

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
            Debug.Log("User created: " + request.downloadHandler.text);
        else
            Debug.LogError("CreateUser Error: " + request.error);
    }

    
    public IEnumerator GetUser(int id)
    {
        string url = $"{baseUrl}/{id}";
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
            Debug.Log("User data: " + request.downloadHandler.text);
        else
            Debug.LogError("GetUser Error: " + request.error);
    }

    
    public IEnumerator UpdateUser(int id, string newName)
    {
        string url = $"{baseUrl}/{id}";
        UnityWebRequest request = new UnityWebRequest(url, "PUT");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes($"\"{newName}\"");

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
            Debug.Log("User updated: " + request.downloadHandler.text);
        else
            Debug.LogError("UpdateUser Error: " + request.error);
    }

    
    public IEnumerator DeleteUser(int id)
    {
        string url = $"{baseUrl}/{id}";
        UnityWebRequest request = UnityWebRequest.Delete(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success || request.responseCode == 204)
            Debug.Log("User deleted successfully.");
        else
            Debug.LogError("DeleteUser Error: " + request.error);
    }
}

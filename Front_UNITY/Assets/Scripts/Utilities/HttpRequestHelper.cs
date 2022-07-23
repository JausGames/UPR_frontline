using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using System;

public class HttpRequestHelper : MonoBehaviour
{
    const string API_URL = "http://back_laravel.test/api/";


    public IEnumerator GetMazeList()
    {
        UnityWebRequest www = UnityWebRequest.Get(API_URL + "mazelist");
        www.SetRequestHeader("USERKEY", MazeUser.GetInstance().GetApiKey());
        yield return www.SendWebRequest();
        string output = null;
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("HttpRequestHelper, GetMazeList: error : " + www.error);
            yield return null;
        }
        else
        {
            output = www.downloadHandler.text;
            yield return output;
            // Show results as text
            Debug.Log("HttpRequestHelper, GetMazeList : success : " + output);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
    public IEnumerator GetMazeJson(int id)
    {
        UnityWebRequest www = UnityWebRequest.Get(API_URL + "maze/json/" + id);
        www.SetRequestHeader("USERKEY", MazeUser.GetInstance().GetApiKey());
        yield return www.SendWebRequest();
        string output = null;
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("HttpRequestHelper, GetMazeJson: error : " + www.error);
            yield return false;
        }
        else
        {
            output = www.downloadHandler.text;
            yield return output;
            // Show results as text

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
            Debug.Log("HttpRequestHelper, GetMazeJson : success : " + results.Length);
        }
    }
    public IEnumerator GetMazeJsonUpr()
    {
        
            yield return '{"Items":[{"type":6,"x":0,"y":0},{"type":2,"x":0,"y":1},{"type":2,"x":0,"y":2},{"type":2,"x":0,"y":3},{"type":2,"x":0,"y":4},{"type":2,"x":0,"y":5},{"type":2,"x":0,"y":6},{"type":2,"x":0,"y":7},{"type":2,"x":0,"y":8},{"type":2,"x":0,"y":9},{"type":6,"x":0,"y":10},{"type":6,"x":1,"y":0},{"type":2,"x":1,"y":1},{"type":2,"x":1,"y":2},{"type":0,"x":1,"y":3},{"type":0,"x":1,"y":4},{"type":0,"x":1,"y":5},{"type":2,"x":1,"y":6},{"type":2,"x":1,"y":7},{"type":2,"x":1,"y":8},{"type":2,"x":1,"y":9},{"type":6,"x":1,"y":10},{"type":6,"x":2,"y":0},{"type":2,"x":2,"y":1},{"type":2,"x":2,"y":2},{"type":0,"x":2,"y":3},{"type":0,"x":2,"y":4},{"type":0,"x":2,"y":5},{"type":2,"x":2,"y":6},{"type":2,"x":2,"y":7},{"type":2,"x":2,"y":8},{"type":2,"x":2,"y":9},{"type":6,"x":2,"y":10},{"type":6,"x":3,"y":0},{"type":2,"x":3,"y":1},{"type":2,"x":3,"y":2},{"type":0,"x":3,"y":3},{"type":0,"x":3,"y":4},{"type":0,"x":3,"y":5},{"type":2,"x":3,"y":6},{"type":2,"x":3,"y":7},{"type":2,"x":3,"y":8},{"type":2,"x":3,"y":9},{"type":6,"x":3,"y":10},{"type":6,"x":4,"y":0},{"type":2,"x":4,"y":1},{"type":3,"x":4,"y":2},{"type":3,"x":4,"y":3},{"type":0,"x":4,"y":4},{"type":3,"x":4,"y":5},{"type":3,"x":4,"y":6},{"type":3,"x":4,"y":7},{"type":3,"x":4,"y":8},{"type":2,"x":4,"y":9},{"type":6,"x":4,"y":10},{"type":6,"x":5,"y":0},{"type":2,"x":5,"y":1},{"type":2,"x":5,"y":2},{"type":2,"x":5,"y":3},{"type":3,"x":5,"y":4},{"type":0,"x":5,"y":5},{"type":0,"x":5,"y":6},{"type":2,"x":5,"y":7},{"type":2,"x":5,"y":8},{"type":2,"x":5,"y":9},{"type":6,"x":5,"y":10},{"type":6,"x":6,"y":0},{"type":2,"x":6,"y":1},{"type":2,"x":6,"y":2},{"type":2,"x":6,"y":3},{"type":0,"x":6,"y":4},{"type":0,"x":6,"y":5},{"type":0,"x":6,"y":6},{"type":2,"x":6,"y":7},{"type":2,"x":6,"y":8},{"type":2,"x":6,"y":9},{"type":6,"x":6,"y":10},{"type":6,"x":7,"y":0},{"type":2,"x":7,"y":1},{"type":2,"x":7,"y":2},{"type":2,"x":7,"y":3},{"type":0,"x":7,"y":4},{"type":0,"x":7,"y":5},{"type":3,"x":7,"y":6},{"type":2,"x":7,"y":7},{"type":2,"x":7,"y":8},{"type":2,"x":7,"y":9},{"type":6,"x":7,"y":10},{"type":6,"x":8,"y":0},{"type":2,"x":8,"y":1},{"type":3,"x":8,"y":2},{"type":3,"x":8,"y":3},{"type":3,"x":8,"y":4},{"type":3,"x":8,"y":5},{"type":0,"x":8,"y":6},{"type":3,"x":8,"y":7},{"type":3,"x":8,"y":8},{"type":2,"x":8,"y":9},{"type":6,"x":8,"y":10},{"type":6,"x":9,"y":0},{"type":2,"x":9,"y":1},{"type":2,"x":9,"y":2},{"type":2,"x":9,"y":3},{"type":2,"x":9,"y":4},{"type":0,"x":9,"y":5},{"type":0,"x":9,"y":6},{"type":0,"x":9,"y":7},{"type":2,"x":9,"y":8},{"type":2,"x":9,"y":9},{"type":6,"x":9,"y":10},{"type":6,"x":10,"y":0},{"type":2,"x":10,"y":1},{"type":2,"x":10,"y":2},{"type":2,"x":10,"y":3},{"type":2,"x":10,"y":4},{"type":0,"x":10,"y":5},{"type":0,"x":10,"y":6},{"type":0,"x":10,"y":7},{"type":2,"x":10,"y":8},{"type":2,"x":10,"y":9},{"type":6,"x":10,"y":10},{"type":6,"x":11,"y":0},{"type":2,"x":11,"y":1},{"type":2,"x":11,"y":2},{"type":2,"x":11,"y":3},{"type":2,"x":11,"y":4},{"type":0,"x":11,"y":5},{"type":0,"x":11,"y":6},{"type":0,"x":11,"y":7},{"type":2,"x":11,"y":8},{"type":2,"x":11,"y":9},{"type":6,"x":11,"y":10},{"type":6,"x":12,"y":0},{"type":2,"x":12,"y":1},{"type":2,"x":12,"y":2},{"type":2,"x":12,"y":3},{"type":2,"x":12,"y":4},{"type":2,"x":12,"y":5},{"type":2,"x":12,"y":6},{"type":2,"x":12,"y":7},{"type":2,"x":12,"y":8},{"type":2,"x":12,"y":9},{"type":6,"x":12,"y":10}]}';
          
    }


    public IEnumerator TryLogin(string name, string password)
    {
        WWWForm data = new WWWForm();
        data.AddField("name", name);
        data.AddField("password", password);

        UnityWebRequest www = UnityWebRequest.Post(API_URL + "user/login", data);

        using (www)
        {

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("HttpRequestHelper, TryLogin : www.error = " + www.error);
                yield return www.error;
            }
            else
            {
                Debug.Log("HttpRequestHelper, TryLogin : www.response = " + www.downloadHandler.text);
                yield return www.downloadHandler.text;
            }

        }
    }
    public IEnumerator RegisterUser(string name, string email, string password)
    {
        WWWForm data = new WWWForm();
        data.AddField("name", name);
        data.AddField("email", email);
        data.AddField("password", password);

        UnityWebRequest www = UnityWebRequest.Post(API_URL + "user", data);

        using (www)
        {

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("HttpRequestHelper, RegisterUser : www.error = " + www.error);
                yield return false;
            }
            else
            {
                Debug.Log("HttpRequestHelper, RegisterUser : www.success = " + www.downloadHandler.text);
                yield return www.downloadHandler.text;
            }

        }
    }

    public IEnumerator UploadMaze(string name, string mapData, int authorId)
    {
        WWWForm data = new WWWForm();
        data.AddField("name", name);
        data.AddField("user_id", authorId);
        data.AddField("composition", mapData);

        UnityWebRequest www = UnityWebRequest.Post(API_URL + "maze", data);

        www.SetRequestHeader("USERKEY", MazeUser.GetInstance().GetApiKey());

        using (www)
        {

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("HttpRequestHelper, UpdateMap : www.error = " + www.error);
                yield return false;
            }
            else
            {
                Debug.Log("HttpRequestHelper, UpdateMap : www.success = " + www.downloadHandler.text);
                yield return true;
            }

        }
    }
    public IEnumerator UpdateMaze(int id, string all)
    {
        using (UnityWebRequest www = UnityWebRequest.Put(API_URL + "maze/" + id, all))
        {
            www.SetRequestHeader("Accept", "application/json");
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("USERKEY", MazeUser.GetInstance().GetApiKey());
            www.uploadHandler.contentType = "application/json";
            Debug.Log("HttpRequestHelper, UpdateMap : rawdata = " + all);
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(all));

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("HttpRequestHelper, UpdateMap : www.error = " + www.error);
                yield return false;
            }
            else
            {
                Debug.Log("HttpRequestHelper, UpdateMap : www.success = " +  www.downloadHandler.text);
                yield return true;
            }
        }
    }
    public IEnumerator SendTest(int mapId, int result)
    {
        WWWForm data = new WWWForm();
        data.AddField("maze_id", mapId);
        data.AddField("result", result);

        UnityWebRequest www = UnityWebRequest.Post(API_URL + "test", data);

        www.SetRequestHeader("USERKEY", MazeUser.GetInstance().GetApiKey());
        Debug.Log("HttpRequestHelper, SendTest : sending test on maze " + mapId);

        using (www)
        {

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("HttpRequestHelper, SendTest : www.error = " + www.error);
                yield return false;
            }
            else
            {
                Debug.Log("HttpRequestHelper, SendTest : www.success = " + www.downloadHandler.text);
                yield return true;
            }

        }
    }
    public IEnumerator GetRandomMaze(string name, int authorId)
    {
        UnityWebRequest www = UnityWebRequest.Get(API_URL + "randommaze/" + name + "/" + authorId);
        www.SetRequestHeader("USERKEY", MazeUser.GetInstance().GetApiKey());
        yield return www.SendWebRequest();
        string output = null;
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("HttpRequestHelper, GetMazeJson: error : " + www.error);
            yield return false;
        }
        else
        {
            output = www.downloadHandler.text;
            yield return output;
            // Show results as text

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
            Debug.Log("HttpRequestHelper, GetMazeJson : success : " + results.Length);
        }
    }
}
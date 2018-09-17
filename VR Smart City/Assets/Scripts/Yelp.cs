using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Yelp : MonoBehaviour 
{
	private const string url = "http://csf.ftp.sh/test?id=";

	public void Start()
	{
		
	}

	public void QueryImageByUrl(string url, Action<Texture> callback)
	{
		StartCoroutine(QueryImageByUrl_Coroutine(url, callback));
	}

	private IEnumerator QueryImageByUrl_Coroutine(string url, Action<Texture> callback)
	{
		string urlEsc = WWW.EscapeURL(url);
		WWW www = new WWW(urlEsc);
		
		yield return www;

		callback(www.texture);
	}
	
	public void QueryPlaceById(string id, Action<YelpResponse> callback) 
	{
		StartCoroutine(QueryPlaceById_Coroutine(id, callback));
	}
	
	private IEnumerator QueryPlaceById_Coroutine(string id, Action<YelpResponse> callback) 
	{
		string idEsc = WWW.EscapeURL(id);
		
		string searchUrl = url + idEsc;
		
		WWW query = new WWW(searchUrl);
		yield return query;
		YelpResponse yelpRes = JsonUtility.FromJson<YelpResponse>(query.text);
		callback(yelpRes);
	}
}
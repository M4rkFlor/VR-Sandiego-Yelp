using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageUrlFetcherBackup : MonoBehaviour {
	public Yelp yelp;
	public Image fetchedIMG;
	public Sprite newSprite;
	// Use this for initialization
	//need to convert Image to 2d and UI
	public string url = "default";
	bool flag = true;

	void Start() {

		yelp.QueryPlaceById ("c1", delegate(YelpResponse res) {
			url = res.imageUrl;
		});
	}

	IEnumerator StartImgGet() {
		Image img = GetComponent<Image>();
		print (url);
		WWW www = new WWW(url);
		yield return www;

		img.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));

	}


	// Update is called once per frame
	void Update () {
		if (!url.Equals ("default") && flag) {
			flag = false;
			StartCoroutine(StartImgGet ());
		}
	}
}

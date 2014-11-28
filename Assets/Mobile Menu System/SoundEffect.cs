using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Sound
{
	tone
}
public class SoundEffect : MonoBehaviour 
{
	public static bool isMute = false;
	static float timeOfSound = 0;
	public AudioSource _audio;
	static SoundEffect instance;
	public static SoundEffect Instance
	{
		get
		{
			GameObject obj = GameObject.Find("SoundEffect");
			if(obj == null)
			{
				obj = (GameObject)Instantiate(Resources.Load("SoundEffect"));
				obj.name = "SoundEffect";
				obj.transform.parent = Camera.main.transform;
				obj.transform.localPosition = new Vector3(0,0,0);			
			}
			instance = obj.GetComponent<SoundEffect>();	
			instance._audio = obj.GetComponent<AudioSource>();
			return instance;
		}
	}
	// Use this for initialization
	void Awake () 
	{
		//_audio = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static float Play(Sound soundName)
	{
		if(isMute)
			return 0;
		Instance._audio.Stop();
		switch(soundName)
		{
			case Sound.tone:
			{
				Instance.StartCoroutine(Instance.Tone());
				break;
			}			
		}
		return timeOfSound;
	}
	public static void Stop()
	{
		Instance._audio.Stop();
	}
	IEnumerator Tone()
	{		
		_audio.clip = (AudioClip)Resources.Load("SoundNameHere");
		_audio.loop = true;
		_audio.Play();		
		yield return new WaitForSeconds(timeOfSound);
	}	
}

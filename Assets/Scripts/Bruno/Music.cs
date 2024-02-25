using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
	public static Music instance;

	private FMOD.Studio.EventInstance instanceMusic;

	public FMODUnity.EventReference fmodEvent;

	[SerializeField]
	private float whiteVolume;
	[SerializeField]
	private float arcadeVolume;
	[SerializeField]
	private float greekVolume;
	[SerializeField]
	private float radioVolume;
	[SerializeField]
	private float elementsVolume;

	public bool whiteBool;
	public bool arcadeBool;
	public bool greekBool;
	public bool radioBool;
	public bool elementBool;

	void Start()
	{
		instance = this;
		instanceMusic = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
		instanceMusic.start();
	}

	// Update is called once per frame
	void Update()
	{
		instanceMusic.setParameterByName("White", whiteVolume);
		instanceMusic.setParameterByName("Arcade", arcadeVolume);
		instanceMusic.setParameterByName("Greek", greekVolume);
		instanceMusic.setParameterByName("Radio", radioVolume);
		instanceMusic.setParameterByName("Elements", elementsVolume);

		if (whiteBool)
		{
			whiteVolume = Mathf.Clamp(whiteVolume + .001f, 0, 1);
		}
		else if (!whiteBool)
		{
			whiteVolume = Mathf.Clamp(whiteVolume - .001f, 0, 1);
		}
		if (arcadeBool)
		{
			arcadeVolume = Mathf.Clamp(arcadeVolume + .001f, 0, 1);
		}
		else if (!whiteBool)
		{
			arcadeVolume = Mathf.Clamp(arcadeVolume - .001f, 0, 1);
		}
	}

	public void ChangeBools(bool unCheck, bool check)
	{
		unCheck = false;
		check = true;
	}

	public IEnumerator IncreaseVolume(float increase)
	{
		float elapsedTime = 0f;
		float endVolume = 1f;

		while (elapsedTime < 3f)
		{
			float increaseLerpFactor = elapsedTime / 3f;
			float increasedVolume = Mathf.Lerp(increase, endVolume, increaseLerpFactor);
			increase = increasedVolume;
			Debug.Log(increase);


			elapsedTime += Time.deltaTime;

			yield return null;
		}
		increase = endVolume;
	}

}

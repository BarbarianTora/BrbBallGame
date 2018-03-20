using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	[SerializeField]
	private PlayerController _playerController = null;

	private int count = 0;
	public Text countText;
	public Text winText;

	void Awake()
	{
		winText.text = string.Empty;
	}

	void OnEnable()
	{
		if (_playerController != null) 
		{
			_playerController.OnPickUpObject += ChangeCounter;
		}
	}

	void OnDisable()
	{
		if (_playerController != null) 
		{
			_playerController.OnPickUpObject -= ChangeCounter;
		}
	}

	private void ChangeCounter ()
	{
		count++;
		countText.text = "Count: " + count.ToString ();
		if (count >= 12)
			winText.text = "Winner!";
	}
}

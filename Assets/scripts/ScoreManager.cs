using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	[SerializeField]
	private PlayerController _playerController = null;

	[SerializeField]
	private Text _countText = null;

	[SerializeField]
	private Text _winText = null;

	public int count = 0;

	void Awake()
	{
		_winText.text = string.Empty;
			 
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
		_countText.text = "Count: " + count.ToString ();
		if (count >= 12) 
		{
			_winText.text = "Winner!";
		}


}
}

using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	[SerializeField]
	private PlayerController _playerController = null;

	[SerializeField]
	private Text _countText = null;

	[SerializeField]
	private Text _winText = null;

	[SerializeField]
	private Text _exitText = null;

	[SerializeField]
	private Image _winImg = null;

	[SerializeField]
	private Button _exitButton = null;





	public static int count = 0;
	//public Button _exitButton;

	void Awake()
	{
		_winText.text = string.Empty;

		//Button exitButton = gameObject.GetComponentInChildren<Button>(true) as Button;
		_exitButton.interactable = false;
		_winImg.enabled = false;
				 
	}

	void Update ()
	{
		if (count >= 12) 
		{
			Button exitButton = gameObject.GetComponentInChildren<Button> (true) as Button;
			_exitButton.interactable = true;
			_exitText.text = "click here to exit";
		}
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
			_winText.text = "You won!";
			_winImg.enabled = true;
		}

	}


}

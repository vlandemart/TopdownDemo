using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
	public static HUDManager Instance;
	[SerializeField]
	private Text scoreText = null;
	[SerializeField]
	private Text ammoText = null;
	[SerializeField]
	private Text interactableText = null;

	void Awake()
	{
		if (Instance != null)
		{
			return;
		}
		Instance = this;
	}

	void Start()
	{
		GameController.Instance.OnScoreChange += UpdateScore;
	}

	public void UpdateScore(int score)
	{
		scoreText.text = "Score: " + score;
	}

	public void UpdateAmmoCounter(int currentAmmo, int maxAmmo)
	{
		ammoText.text = currentAmmo + "/" + maxAmmo;
	}

	public void SetInteractableText(string text)
	{
		interactableText.gameObject.SetActive(true);
		interactableText.text = text;
	}

	public void HideInteractableText()
	{
		interactableText.gameObject.SetActive(false);
	}
}

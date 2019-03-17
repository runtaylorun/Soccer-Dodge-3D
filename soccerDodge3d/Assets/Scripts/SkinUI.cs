using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkinUI : MonoBehaviour
{

    private GameObject displayModel;
    public Button lockButton;
    public Button playButton;
    public Animator confirmation;
    public AudioSource buttonPress;
    public AudioSource denyPress;

    public Text confirmationText;
    public Text CoinText;
    public Text ModelCostText;

    private Vector3 displayPosition;
    private Vector3 modelRotation;
    private GameObject clone;
    private bool modelIsShowing;
    private float spinSpeed = 70f;

    private int skin1Lock;
    private int skin2Lock;
    private int skin3Lock;
    private int skin4Lock;
    private int skin5Lock;
    private int skin6Lock;
    private int skin7Lock;
    private int skin8Lock;
    private int skin9Lock;
    private int skin10Lock;
    private int skin11Lock;
    private int skin12Lock;
    private int skin13Lock;
    private int skin14Lock;
    private int skin15Lock;
    private int skin16Lock;
    private int skin17Lock;
    private int skin18Lock;

    public AudioSource coinSubtract;
    public AudioSource purchased;

    private modelData modelData;

    private int playerCoins;
    private static int selectedSkinsCost;

    void Start()
    {
        playerCoins = PlayerPrefs.GetInt("Coins", 0);
        InitializeLocks();
        PlayerPrefs.SetInt("skinLock1", 1);
        displayPosition = new Vector3(113.372f, 27.317f, -3709.563f);
        modelRotation = new Vector3(0, 180, 0);
        modelIsShowing = false;
        CoinText.text = playerCoins.ToString();
        ModelCostText.text = "Cost: 0";
        ModelCostText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (modelIsShowing == true)
        {
            clone.transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
        }
    }

    public void LockButton()
    {
        buttonPress.Play();
        confirmationText.text = "Confirm Purchase " + selectedSkinsCost;
        confirmation.SetBool("Confirmation", true);
        Debug.Log(selectedSkinsCost);
    }

    public void ShowSkin1()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("PlayerDisplay", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = skin1Lock;
        CheckIfCharacterLocked();
        ModelCostText.text = "Cost: " + modelData.cost;
        selectedSkinsCost = 0;
        modelIsShowing = true;
        closeConfirmationMenu();
    }

    public void ShowSkin2()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player2Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = skin2Lock;
        CheckIfCharacterLocked();
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void ShowSkin3()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player3Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = skin3Lock;
        CheckIfCharacterLocked();
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void ShowSkin4()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player4Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = skin4Lock;
        CheckIfCharacterLocked();
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void ShowSkin5()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player5Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = skin5Lock;
        CheckIfCharacterLocked();
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void ShowSkin6()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player6Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = skin6Lock;
        CheckIfCharacterLocked();
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void ShowSkin7()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player7Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = skin7Lock;
        CheckIfCharacterLocked();
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void ShowSkin8()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player8Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = skin8Lock;
        CheckIfCharacterLocked();
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void ShowSkin9()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player9Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = skin9Lock;
        CheckIfCharacterLocked();
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void ShowSkin10()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player10Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = skin10Lock;
        CheckIfCharacterLocked();
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void ShowSkin11()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player11Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = skin11Lock;
        CheckIfCharacterLocked();
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void ShowSkin12()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player12Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = skin12Lock;
        CheckIfCharacterLocked();
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void ShowSkin13()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player13Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = skin13Lock;
        CheckIfCharacterLocked();
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void ShowSkin14()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player14Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = skin14Lock;
        CheckIfCharacterLocked();
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void ShowSkin15()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player15Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = skin15Lock;
        CheckIfCharacterLocked();
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void ShowSkin16()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player16Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = skin16Lock;
        CheckIfCharacterLocked();
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void ShowSkin17()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player17Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = skin17Lock;
        CheckIfCharacterLocked();
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void ShowSkin18()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player18Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = skin18Lock;
        CheckIfCharacterLocked();
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void LoadGame()
    {
        buttonPress.Play();
        SceneManager.LoadScene("Game");
        PlayerPrefs.SetInt("characterIndex", modelData.charIndex);
        closeConfirmationMenu();
    }

    public void InitializeLocks()
    {
        skin1Lock = PlayerPrefs.GetInt("skin1Lock", 1);
        skin2Lock = PlayerPrefs.GetInt("skin2Lock", 0);
        skin3Lock = PlayerPrefs.GetInt("skin3Lock", 0);
        skin4Lock = PlayerPrefs.GetInt("skin4Lock", 0);
        skin5Lock = PlayerPrefs.GetInt("skin5Lock", 0);
        skin6Lock = PlayerPrefs.GetInt("skin6Lock", 0);
        skin7Lock = PlayerPrefs.GetInt("skin7Lock", 0);
        skin8Lock = PlayerPrefs.GetInt("skin8Lock", 0);
        skin9Lock = PlayerPrefs.GetInt("skin9Lock", 0);
        skin10Lock = PlayerPrefs.GetInt("skin10Lock", 0);
        skin11Lock = PlayerPrefs.GetInt("skin11Lock", 0);
        skin12Lock = PlayerPrefs.GetInt("skin12Lock", 0);
        skin13Lock = PlayerPrefs.GetInt("skin13Lock", 0);
        skin14Lock = PlayerPrefs.GetInt("skin14Lock", 0);
        skin15Lock = PlayerPrefs.GetInt("skin15Lock", 0);
        skin16Lock = PlayerPrefs.GetInt("skin16Lock", 0);
        skin17Lock = PlayerPrefs.GetInt("skin17Lock", 0);
        skin18Lock = PlayerPrefs.GetInt("skin18Lock", 0);

    }

    public void closeConfirmationMenu()
    {
        confirmation.SetBool("Confirmation", false);
    }

    public void declinePurchaseButton()
    {
        buttonPress.Play();
        confirmation.SetBool("Confirmation", false);
    }

    public void acceptPurchase()
    {
        if (playerCoins >= selectedSkinsCost)
        {
            playerCoins -= selectedSkinsCost;
            CoinText.text = playerCoins.ToString();
            confirmation.SetBool("Confirmation", false);
            PlayerPrefs.SetInt(modelData.lockStat, 1);
            lockButton.gameObject.SetActive(false);
            playButton.gameObject.SetActive(true);
            InitializeLocks();
            PlayerPrefs.SetInt("Coins", playerCoins - modelData.cost);
            purchased.Play();
        }
        else
        {
            denyPress.Play();
            StartCoroutine("FlashDeclinedPurchase");
        }
    }

    IEnumerator FlashDeclinedPurchase()
    {
        confirmationText.text = "Not Enough Coins!";
        yield return new WaitForSeconds(0.3f);
        confirmationText.enabled = false;
        yield return new WaitForSeconds(0.3f);
        confirmationText.enabled = true;
        yield return new WaitForSeconds(0.3f);
        confirmationText.enabled = false;
        yield return new WaitForSeconds(0.3f);
        confirmationText.text = "Confirm Purchase " + selectedSkinsCost;
        confirmationText.enabled = true;
    }

    IEnumerator subtractCoins()
    {
        for (int i = 0; i <= selectedSkinsCost; i++)
        {
            yield return new WaitForSeconds(0.0000000000001f);
            coinSubtract.Play();
            CoinText.text = playerCoins.ToString();
            playerCoins--;
            Debug.Log(playerCoins);
        }
    }

    private void ShowLockedUI()
    {
        playButton.gameObject.SetActive(false);
        lockButton.gameObject.SetActive(true);
        ModelCostText.gameObject.SetActive(true);
    }

    private void ShowUnlockedUI()
    {
        lockButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
        ModelCostText.gameObject.SetActive(false);
    }

    private void CheckIfCharacterLocked()
    {
        if (modelData.lockStatus == 1)
        {
            ShowUnlockedUI();
        }
        else
        {
            ShowLockedUI();
        }
    }
}

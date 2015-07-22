using UnityEngine;
using System.Collections;
using SIS;

public class GameMaster : MonoBehaviour 
{
	public GameObject buyEnergy;

	public bool enableEnergyLimit;
	public bool debug;

    public string faseAtual;

    public int[] powerUpTiers;

    public int idPrimeiraFase;
    public int idUltimaFase;

    public float debugTimeScale;

    public static GameObject gameMaster;

    public int Energia
    {
        get
        {
            return PlayerPrefs.GetInt("Energia");
        }
        set
        {
            PlayerPrefs.SetInt("Energia", value);
        }
    }
    public int Coins {
        get 
        {
            return SIS.DBManager.GetFunds("coins");
        }
    }

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	void Start () 
	{
        if(PlayerPrefs.GetInt("Primeira") == 0)
		{
			PlayerPrefs.SetInt("Energia", 100);
			PlayerPrefs.SetInt("Primeira", 1);
		}
	}

    void Update()
    {
        if (debug)
        {
            Time.timeScale = debugTimeScale;
            var tempo = Time.timeSinceLevelLoad;
            print(tempo);
        }
    }

    public bool CanPlay()
    {
        if (enableEnergyLimit)
        {
            return Energia > 0;
        }
        return true;
    }

    void CheckPowerStarUps()
    {
        //soma todas as estrelas já obtidas;
        var qtdEstrelas = 0;
        for (int i = idPrimeiraFase; i <= idUltimaFase; i++)
        {
            qtdEstrelas += GetStarsForLevel(i);
        }

        var tiersQtd = powerUpTiers.Length;
        var powerUpsObtidos = PlayerPrefs.GetInt("StarPowerUps");

        //inicia a partir do tier já conquistado
        for (int i = powerUpsObtidos - 1; i < tiersQtd; i++)
        {
            if (qtdEstrelas > powerUpTiers[i])
            {
                GetFreePowerUp();
                PlayerPrefs.SetInt("StarPowerUps", ++powerUpsObtidos);
            }
            else break;
        }
    }

    void GetFreePowerUp() 
    {
        print("GetFreePowerUp() has not been implemented yet");
    }

    public int GetStarsForLevel(int level)
    {
        return PlayerPrefs.GetInt("Stars_" + level.ToString());
    }

    public void SetStarsForLevel(int stars)
    {
        PlayerPrefs.SetInt("Stars_" + faseAtual, stars);
        
    }

	public void NextLevel() 
	{
		OnChangeLevel (int.Parse(faseAtual) + 1);
	}

    public void OnChangeLevel(int level)
    {
        if (level >= idPrimeiraFase)
        {
            if (CanPlay())
            {
                Energia--;
                faseAtual = level.ToString();
            }
            else 
            {
                GetMoreEnergyPopUp();
                return;
            }
        }
		//redundante?
		if(CanPlay() || level < idPrimeiraFase)
		{
        	LoadScene(level, 0);
		}
		else
		{
			GetMoreEnergyPopUp();
			return;
		}
    }

    private void LoadScene(int level, int x)
    {
        if (x == 0)
        {
            PlayerPrefs.SetInt("Loading", level);
            Application.LoadLevel("Loading");
        }
        else
        {
            Application.LoadLevel("Loading");
        }
    }

    void GetMoreEnergyPopUp()
    {
		if(Energia < 0)
		{
			Energia = 0;
		}
		Instantiate(buyEnergy);
    }
}

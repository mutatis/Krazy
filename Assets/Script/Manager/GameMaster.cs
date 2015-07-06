using UnityEngine;
using System.Collections;
using SIS;

public class GameMaster : MonoBehaviour {
    public bool enableEnergyLimit;
    public string faseAtual;
    public int[] powerUpTiers;
    public int idPrimeiraFase;
    public int idUltimaFase;
    public float debugTimeScale;
    public bool debug;

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

	void Start () 
	{
        DontDestroyOnLoad(gameObject);
	}

    void Update()
    {
        if (debug)
        {
            Time.timeScale = debugTimeScale;
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
        LoadScene(level, 0);
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

    private void GetMoreEnergyPopUp()
    {
        print("GetMoreEnergyPopUp() has not been implemented yet");
    }
}

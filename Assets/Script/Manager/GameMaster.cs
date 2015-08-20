using UnityEngine;
using System.Collections;
//using SIS;

public class GameMaster : MonoBehaviour
{
    public GameObject buyEnergy;

    public bool enableEnergyLimit;
    public bool debug;

    public int faseAtual;

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
    public int Coins
    {
        get
        {
            //return DBManager.GetFunds("coins");
            return 99999;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("Primeira") == 0)
        {
            PlayerPrefs.SetInt("Energia", 100);
            PlayerPrefs.SetInt("Primeira", 1);
        }
        //DBManager.SetFunds("coins", 1000000000);
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
        print("Next Level: " + faseAtual);
        OnChangeLevel(Application.loadedLevel + 1);
    }

    public void OnChangeLevel(int level)
    {
        print("OnChangeLevel: " + level);
        if (CanPlay() || level < idPrimeiraFase)
        {
            if (level >= idPrimeiraFase)
                Energia--;

            faseAtual = level;
            Debug.LogError(faseAtual + "." + gameObject.GetInstanceID());
            LoadScene(level, 0);
        }
        else if (!CanPlay())
        {
            GetMoreEnergyPopUp();
        }
    }

    private void LoadScene(int level, int x)
    {
        print(level);
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
        if (Energia < 0)
        {
            Energia = 0;
        }
        Instantiate(buyEnergy);
    }

    public int GetPowerUpCount(PowerUps powerup)
    {
        var tag = GetPowerUpTag(powerup);
        return PlayerPrefs.GetInt(tag);
    }

    public void ConsumePowerUp(PowerUps powerup)
    {
        var tag = GetPowerUpTag(powerup);
        var val = PlayerPrefs.GetInt(tag);
        val--;
        PlayerPrefs.SetInt(tag, val);
    }

    private string GetPowerUpTag(PowerUps powerup)
    {
        string powerUpTag = "";
        switch (powerup)
        {
            case PowerUps.Revive:
                {
                    powerUpTag = "PowerUp3";
                    break;
                }
            case PowerUps.Slow:
                {
                    powerUpTag = "PowerUp1";
                    break;
                }
            case PowerUps.Bomba:
                {
                    powerUpTag = "PowerUp2";
                    break;
                }
            case PowerUps.ExtraTime:
                {
                    powerUpTag = "PowerUp4";
                    break;
                }
        }

        return powerUpTag;
    }

    void OnLevelWasLoaded(int level)
    {
        faseAtual = Application.loadedLevel;
    }
}

public enum PowerUps
{
    Revive,
    ExtraTime,
    Bomba,
    Slow
}
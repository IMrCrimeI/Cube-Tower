using UnityEngine.Advertisements;
using UnityEngine;
using System.Collections;

public class Ads : MonoBehaviour
{
    private Coroutine showAd;

    private string gameId = "4015289", type = "Video";
    private bool testMode = true, needToStop ;

    private static int countLoses;

    private void Start()
    {
        Advertisement.Initialize(gameId, testMode);

        countLoses++;
        if(countLoses %3 == 0)
            showAd = StartCoroutine(ShowAd());
    }

    private void Update()
    {
        if(needToStop)
        {
            needToStop = false;
            StopCoroutine(showAd);
        }
    }

    IEnumerator ShowAd()
    {
        while (true)
        {
            if (Advertisement.IsReady(type))
            {
                Debug.Log("Ready");
                Advertisement.Show(type);
                needToStop = true;
            }

            yield return new WaitForSeconds(1f);
        }
    }

}

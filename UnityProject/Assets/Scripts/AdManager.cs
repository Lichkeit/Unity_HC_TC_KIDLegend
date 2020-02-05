
using UnityEngine;
using UnityEngine.Advertisements;  //引用廣告API

public class AdManager : MonoBehaviour
{
    private string googlePlay = "3457977";

    private void Start()
    {
        Advertisement.Initialize(googlePlay, true);
    }


}

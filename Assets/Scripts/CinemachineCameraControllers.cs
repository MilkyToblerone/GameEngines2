using System.Collections;
using UnityEngine;

public class CinemachineCameraControllers : MonoBehaviour
{
    [SerializeField] GameObject[] cinemachineCameas;
    [SerializeField] GameObject firstadam;
    [SerializeField] GameObject jumpsacer;
    void Start()
    {
        StartCoroutine(CamerasCourotine());
    }

    void Update()
    {
    }
    
    public IEnumerator CamerasCourotine()
    {
        print("hello i worek");
        yield return new WaitForSeconds(1);
        print("hello i worek2");
        cinemachineCameas[1].SetActive(true);
        yield return new WaitForSeconds(2);
        cinemachineCameas[2].SetActive(true);
        firstadam.SetActive(false);
        yield return new WaitForSeconds(2);
        cinemachineCameas[3].SetActive(true);
        yield return new WaitForSeconds(1);
        cinemachineCameas[4].SetActive(true);
        yield return new WaitForSeconds(2);
        cinemachineCameas[5].SetActive(true);
        yield return new WaitForSeconds(2);
        cinemachineCameas[6].SetActive(true);
        jumpsacer.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        cinemachineCameas[7].SetActive(true);
        yield return new WaitForSeconds(1);
        cinemachineCameas[8].SetActive(true);

    } 
}

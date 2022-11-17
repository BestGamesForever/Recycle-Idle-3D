using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class TargetRemoveFromListWhenHit : MonoBehaviour
{
    public GameObject PotionImage;
    public Vector3 offset;
    public GameObject ImageContainerTransform;
    public static int value;
    public TextMeshProUGUI _totalMoney;
    public static int lastmoney;
    private void Start()
    {      
        lastmoney = GameManager.Instance.totalCoins;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            StartCoroutine(RemoveFromList(other));
        }
    }
    IEnumerator RemoveFromList(Collider other)
    {
        yield return new WaitForSeconds(1);
        if (other.gameObject.name != "StaticEnemy")
        {
            for (int i = 0; i < 5; i++)
            {
                var Intans = Instantiate(PotionImage, Camera.main.WorldToScreenPoint(other.transform.position - offset), Quaternion.Euler(Vector3.zero), ImageContainerTransform.transform);
                Intans.name = i.ToString();
            }
        }     
        value = lastmoney;
     
        _totalMoney.text = "$" + (value).ToString();
        other.gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(.1f);     
    }


}
// Vector3 dir = other.ClosestPoint(other.transform.position);
// dir = -dir.normalized;
// other.gameObject.GetComponent<Rigidbody>().AddForce(-dir * force,ForceMode.Impulse);
// Debug.Log("dir" + dir);
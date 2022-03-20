using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManagerCharacter : MonoBehaviour
{
    public int numberCharactor=0;
    public Character[] listCharactor;

    public Transform transform;

    public Image image;

    private GameObject OB1;
    private GameObject OB2;
    // Start is called before the first frame update
    private void Awake()
    {
        Character ob1 = listCharactor[0];

        OB1 = Instantiate(ob1.m_prefabs, transform.position, Quaternion.Euler(new Vector3(0,180,0)));

        Character ob2 = listCharactor[1];

        OB2 = Instantiate(ob2.m_prefabs, transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));

        

        OB1.SetActive(false);

        OB2.SetActive(false);
    }
    void Start()
    {
        OB1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectCharactor2()
    {
        OB1.SetActive(false);
        OB2.SetActive(true);
        image.sprite = listCharactor[1].sprite;
    }
    public void SelectCharactor1()
    {
        OB2.SetActive(false);
        OB1.SetActive(true);
        image.sprite = listCharactor[0].sprite;
    }
}

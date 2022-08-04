using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "Fuck You", menuName = "Invetntory/Item")]
public class Item : ScriptableObject
{

    [SerializeField] public string itemName = "";
    [SerializeField] public Sprite icon = null;
    [SerializeField] public bool isAbility = false;
    [SerializeField] public GameObject gameObject = null;

}

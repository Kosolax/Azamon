using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class magnitude : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = characterController.gameObject.GetComponent<Player>().Movement.Velocity.y.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelswitch : MonoBehaviour
{
    public GameObject Panel;

    public void panelcontrol()
    {
        if(Panel != null)
        {
            Animator showlist = Panel.GetComponent<Animator>();
            if(showlist != null)
            {
                bool check = Panel.activeSelf;
                bool check2 = showlist.GetBool("click");
                Panel.SetActive(!check);
                showlist.SetBool("click", !check2);

            }
        }
    }
}

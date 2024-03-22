using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Controllers
{
    public class MenuController : MonoBehaviour
    {
        void Update()
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Intro_Scene {
    public class IntroSceneManager : MonoBehaviour
    {
        public string Scene = "Game_Scene";
        public float Time = 0.5f;

        private WaitForSeconds wait;
        private void Start() {
            wait = new WaitForSeconds(Time);
            StartCoroutine(LoadScene());
        }

        private IEnumerator LoadScene()
        {
            yield return wait;
            SceneManager.LoadScene(Scene, LoadSceneMode.Single);
        }
    }
}
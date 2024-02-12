using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity
{
    public class UnityScene : MonoBehaviour
    {
        /*******************************************************************************************
         * 씬 (Scene)
         * 
         * 유니티에서 게임월드를 구성하는 단위
         * 프로젝트에 원하는 수만큼 씬을 포함할 수 있고 씬전환을 통해 다른 게임월드를 불러올 수 있음
         * 다중 씬을 이용하여 여러 씬을 동시에 열어 같은 게임월드에서 사용도 가능함
         ********************************************************************************************/

        // <빌드 설정>
        // 유니티에서 여러 씬을 사용하기 위해선 빌드 설정에서 씬을 포함해야 함
        // 빌드 설정에서 포함한 씬을 게임 빌드 결과물에 포함함


        // <씬 전환>
        // 프로젝트에 포함된 다른 씬을 로딩하고 기존의 씬의 내용을 삭제함
        public void ChangeScene()
        {
            SceneManager.LoadScene("SceneName");
        }


        // <씬 추가>
        // 프로젝트에 포함된 다른 씬을 로딩하고 기존의 씬의 내용을 유지함
        public void AddScene()
        {
            SceneManager.LoadScene("SceneName", LoadSceneMode.Additive);
        }


        // <비동기 씬 로드>
        // 씬 로딩을 백그라운드로 진행하여 게임 중 멈춤이 없도록하는 비동기 방법
        public void ChangeSceneASync()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync("SceneName");

            operation.allowSceneActivation = true;      // 씬 로딩 완료시 바로 씬 전환을 진행하는지 여부
            bool isLoaded = operation.isDone;           // 씬 로딩의 완료여부 확인
            float progress = operation.progress;        // 씬 로딩의 진행률 확인
            operation.completed += (oper) => { };       // 씬 로딩의 완료시 진행할 이벤트 추가
        }
        

        // <Don't destroy on load>
        // 씬의 전환에도 제거되지 않기 원하는 게임오브젝트의 경우 지워지지 않는 씬에 게임오브젝트로 추가하는 방법을 사용
        // Don't destroy on load 씬의 경우 씬 전환 과정 중에 삭제하지 않음
        public void SetDontDestroyOnLoad()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
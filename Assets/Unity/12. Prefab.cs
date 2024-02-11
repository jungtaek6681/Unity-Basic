using UnityEngine;

namespace Unity
{
    public class UnityPrefab : MonoBehaviour
    {
        /********************************************************************************
         * 프리팹 (Prefab)
         * 
         * 미리 만들어 놓은 게임오브젝트, 템플릿, 설계도
         * 프리팹 시스템을 이용하여 게임오브젝트를 생성, 설정 및 저장할 수 있음
         * 자주 사용하는 게임오브젝트 구성을 복사하여 런타임 시점에 생성하려는 경우 사용
         ********************************************************************************/

        // <프리팹 생성>
        // 유니티 하이어라키 창의 게임오브젝트를 프로젝트 창을 드래그 & 드롭하여 프리팹에셋 생성


        // <프리팹 특징>
        // 게임오브젝트를 프리팹화 시킨 프리팹에셋은 게임오브젝트의 모든 컴포넌트, 속성값, 자식 게임오브젝트를 가지고 있음
        // 프리팹에셋을 게임씬에 추가할 경우 프리팹인스턴스로 생성
        // 프리팹에셋의 변경사항은 프리팹인스턴스에게 자동으로 반영
        // 프리팹인스턴스에 변경사항이 있을 경우 해당 변경사항은 프리팹인스턴스에 영향을 받지 않음
        // 프리팹에셋을 클래스, 프리팹인스턴스를 클래스의 인스턴스로 볼 수 있음


        // <프리팹 런타임 생성>
        // 유니티에서 프리팹은 게임오브젝트를 생성하기 위한 설계도 역할을 함
        // 런타임 중 프리팹에셋을 이용하여 프리팹인스턴스를 생성 가능
        public GameObject gameObjectPrefab;     // 프리팹 참조변수
        public Component componentPrefab;       // 프리팹의 컴포넌트 참조변수
        public void Instantiate()
        {
            // Instantiate을 통해 프리팹인스턴스 런타임 생성
            GameObject instance = Instantiate(gameObjectPrefab, Vector3.zero, Quaternion.identity);
            Component component = Instantiate(componentPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
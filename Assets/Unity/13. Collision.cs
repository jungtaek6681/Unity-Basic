using UnityEngine;

namespace Unity
{
    public class UnityCollision : MonoBehaviour
    {
        /***********************************************************************
         * 충돌 (Collision)
         * 
         * 충돌체 : 게임오브젝트의 물리적 충돌을 목적으로 모양을 정의
         * 게임오브젝트 간의 충돌체로 부딪힘과 반발력을 처리
         * 충돌체는 충돌상황에 있을 경우 유니티 충돌 메시지를 받아 상황을 확인
         ***********************************************************************/

        // <유니티 충돌 메시지>
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("OnCollisionEnter");
        }

        private void OnCollisionStay(Collision collision)
        {
            Debug.Log("OnCollisionStay");
        }

        private void OnCollisionExit(Collision collision)
        {
            Debug.Log("OnCollisionExit");
        }



        /*******************************************************************************
         * 트리거 (Trigger)
         * 
         * 하나의 충돌체가 충돌을 일으키지 않고 다른 충돌체의 공간에 들어가는 것을 감지
         * 트리거는 겹침상황에 있을 경우 유니티 트리거 메시지를 받아 상황을 확인
         *******************************************************************************/

        // <유니티 트리거 메시지>
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter");
        }

        private void OnTriggerStay(Collider other)
        {
            Debug.Log("OnTriggerStay");
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log("OnTriggerExit");
        }



        /**********************************************************************************
         * 레이어기반 충돌 & 트리거 감지
         * 
         * 게임오브젝트의 레이어를 활용하여 충돌체간의 충돌가능 여부를 설정 가능
         * 충돌 여부를 제외한 레이어간의 충돌은 무시됨
         * edit -> ProjectSettings -> Physics -> Layer Collision Matrix
         **********************************************************************************/



        /**********************************************************************************
         * 충돌체 & 트리거 종류
         * 
         * 두 게임오브젝트가 충돌하면 리지드바디의 환경설정에 따라 다른 반응을 할 수 있음
         * 일부 조합의 경우 두 게임오브젝트 중에서 하나만 충돌의 영향을 받음
         * 일반적으로 Rigidbody 컴포넌트가 있는 게임오브젝트가 물리가 적용되는 것이 원칙
         **********************************************************************************/

        // <충돌체 종류>
        // (1) 정적 충돌체 (Static Collider)
        // Rigidbody가 없는 충돌체, 외부에 힘에 움직이지 않음
        // 절대로 움직이지 않는 지형, 구성요소에 주로 사용

        // (2) 리지드바디 충돌체 (Rigidbody Collider)
        // Rigidbody가 있는 충돌체, 외부에 힘을 받아 움직임
        // 충돌하여 힘을 받아 움직이는 물체에 사용

        // (3) 키네마틱 충돌체 (Kinematic Collider)
        // Kinematic Rigidbody가 있는 충돌체, 외부의 힘에 반응하지 않음
        // 움직이지만 외부 충격에는 밀리지 않는 물체에 사용
        // Kinematic 상태를 활성화/비활성화 하여 움직임 여부를 설정하는 경우에도 사용


        // <충돌체 & 트리거 상호작용 매트릭스>
        // 충돌체와 트리거의 종류에 따라 메시지가 전송되는 경우가 다름
        // 편의상 정적충돌체(SC), 리지드바디충돌체(RC), 키네마틱충돌체(KC)로 표현
        // 편의상 정적트리거(ST), 리지드바디트리거(RT), 키네마틱트리거(KT)로 표현

        // 충돌시 충돌 메시지가 전송
        //      SC  RC  KC  ST  RT  KT
        // SC        O
        // RC    O   O   O
        // KC        O
        // ST
        // RT
        // KT

        // 트리거시 트리거 메시지가 전송
        //      SC  RC  KC  ST  RT  KT
        // SC                    O   O
        // RC                O   O   O
        // KC                O   O   O
        // ST        O   O       O   O
        // RT    O   O   O   O   O   O
        // KT    O   O   O   O   O   O
    }
}
using System.Collections;
using UnityEngine;

namespace Unity
{
    public class UnityCoroutine : MonoBehaviour
    {
        /**********************************************************************************
	     * 코루틴 (Coroutine)
	     * 
	     * 작업을 다수의 프레임에 분산하여 처리하는 비동기식 작업
	     * 실행을 일시정지하고 중단한 부분부터 재개하여 처리하는 것으로 작업을 분산처리함
	     * 코루틴은 스레드가 아니며 코루틴의 작업은 메인 스레드에서 실행
	     **********************************************************************************/

        // <코루틴 반복 작업>
        // IEnumerator를 반환형으로 함수를 구성
        IEnumerator Routine()
        {
            Debug.Log(0);
            yield return new WaitForSeconds(1f);
            Debug.Log(1);
            yield return new WaitForSeconds(1f);
            Debug.Log(2);
            yield return new WaitForSeconds(1f);
            Debug.Log(3);
            yield return new WaitForSeconds(1f);
            Debug.Log(4);
            yield return new WaitForSeconds(1f);
            Debug.Log(5);
        }

        // <코루틴 변수>
        // 코루틴을 관리하는 객체를 참조하는 변수
        Coroutine coroutine;

        // <코루틴 시작>
        // StartCoroutine을 통해 실행
        private void OnEnable()
        {
            coroutine = StartCoroutine(Routine());
        }

        // <코루틴 종료>
        // StopCoroutine을 통해 코루틴 종료
        // StopAllCoroutines을 통해 진행중인 모든 코루틴 종료
        // 반복가능한 작업이 모두 완료되었을 경우 자동 종료
        // 코루틴을 진행중인 게임오브젝트가 비활성화된 경우 자동 종료
        private void OnDisable()
        {
            StopCoroutine(coroutine);
            StopAllCoroutines();
        }

        // <코루틴 지연>
        // 코루틴은 반복작업 중 지연처리를 정의하여 작업의 진행 타이밍을 지정할 수 있음
        IEnumerator CoroutineWait()
        {
            yield return null;                              // 한 프레임 지연
            yield return new WaitForSeconds(1f);            // n초간 시간 지연
            yield return new WaitForSecondsRealtime(1f);    // 현실 n초간 시간 지연
            yield return new WaitForFixedUpdate();          // FixedUpdate 까지 지연
            yield return new WaitForEndOfFrame();           // 프레임의 끝까지 지연
            yield return new WaitUntil(() => true);         // 조건이 충족할때까지 지연
        }
    }
}
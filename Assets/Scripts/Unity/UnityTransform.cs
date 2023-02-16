using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTransform : MonoBehaviour
{
	/************************************************************************
	 * 트랜스폼 (Transform)
	 * 
	 * 게임오브젝트의 위치, 회전, 크기를 저장하는 컴포넌트
	 * 게임오브젝트의 부모-자식 상태를 저장하는 컴포넌트
	 * 게임오브젝트는 반드시 하나의 트랜스폼 컴포넌트를 가지고 있으며 추가 & 제거할 수 없음
	 ************************************************************************/

	float moveSpeed = 3;
	float rotateSpeed = 90;

	// <트랜스폼 이동>
	// Translate : 트랜스폼의 이동 함수
	private void TranslateMove()
	{
		// 백터를 이용한 이동
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		// x,y,z를 이용한 이동
		transform.Translate(0, 0, moveSpeed * Time.deltaTime);
	}

	// <트랜스폼 이동 기준>
	private void TransformMoveSpace()
	{
		// 월드를 기준으로 이동
		transform.Translate(1, 0, 0, Space.World);
		// 로컬을 기준으로 이동
		transform.Translate(1, 0, 0, Space.Self);
		// 다른 대상을 기준으로 이동
		transform.Translate(1, 0, 0, Camera.main.transform);
	}

	// <트랜스폼 회전>
	// Rotate : 트랜스폼의 회전 함수
	private void Rotate()
	{
		// 축을 이용한 회전 (축을 기준으로 시계방향으로 회전)
		transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
		// 오일러를 이용한 회전
		transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
		// x,y,z를 이용한 회전
		transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
	}

	// <트랜스폼 회전 기준>
	private void RotateSpace()
	{
		// 월드를 기준으로 회전
		transform.Rotate(1, 0, 0, Space.World);
		// 로컬을 기준으로 회전
		transform.Rotate(1, 0, 0, Space.Self);
		// 위치를 기준으로 회전
		transform.RotateAround(Camera.main.transform.position, Vector3.up, 1);
	}

	// <트랜스폼 LookAt 회전>
	// LookAt : 위치를 바라보는 방향으로 회전
	private void LookAt()
	{
		// 위치를 바라보는 회전
		transform.LookAt(new Vector3(0, 0, 0));
		// 머리의 방향을 추가한 바라보는 회전
		transform.LookAt(new Vector3(0, 0, 0), Vector3.right);
	}

	// <Quarternion & Euler>
	// Quarternion	: 유니티의 게임오브젝트의 3차원 방향을 저장하고 이를 방향에서 다른 방향으로의 상대 회전으로 정의
	//				  기하학적 회전으로 짐벌락 현상이 발생하지 않음
	// EulerAngle	: 3축을 기준으로 각도법으로 회전시키는 방법
	//				  직관적이지만 짐벌락 현상이 발생하여 회전이 겹치는 축이 생길 수 있음
	// 짐벌락		: 같은 방향으로 오브젝트의 두 회전 축이 겹치는 현상

	// Quarternion을 통해 회전각도를 계산하는 것은 직관적이지 않고 이해하기 어려움
	// 보통의 경우 쿼터니언 -> 오일러각도 -> 연산진행 -> 결과오일러각도 -> 결과쿼터니언 과 같이 연산의 결과 쿼터니언을 사용함
	private void Rotation()
	{
		// 트랜스폼의 회전값은 Euler각도 표현이 아닌 Quaternion을 사용함
		transform.rotation = Quaternion.identity;

		// Euler각도를 Quaternion으로 변환
		transform.rotation = Quaternion.Euler(0, 90, 0);
	}

	// <트랜스폼 부모-자식 상태>
	// 트랜스폼은 부모 트랜스폼을 가질 수 있음
	// 부모 트랜스폼이 있는 경우 부모 트랜스폼의 위치, 회전, 크기 변경이 같이 적용됨
	// 이를 이용하여 계층적 구조를 정의하는데 유용함 (ex. 팔이 움직이면, 손가락도 같이 움직임)
	// 하이어라키 창 상에서 드래그 & 드롭을 통해 부모-자식 상태를 변경할 수 있음
	private void TransformParent()
	{
		GameObject newGameObject = new GameObject() { name = "NewGameObject" };

		// 부모 지정
		transform.parent = newGameObject.transform;

		// 부모를 기준으로한 트랜스폼
		// transform.localPosition	: 부모트랜스폼이 있는 경우 부모를 기준으로 한 위치
		// transform.localRotation	: 부모트랜스폼이 있는 경우 부모를 기준으로 한 회전
		// transform.localScale		: 부모트랜스폼이 있는 경우 부모를 기준으로 한 크기

		// 부모 해제
		transform.parent = null;

		// 월드를 기준으로한 트랜스폼
		// transform.localPosition == transform.position	: 부모트랜스폼이 없는 경우 월드를 기준으로 한 위치
		// transform.localRotation == transform.rotation	: 부모트랜스폼이 없는 경우 월드를 기준으로 한 회전
		// transform.localScale								: 부모트랜스폼이 없는 경우 월드를 기준으로 한 크기
	}
}

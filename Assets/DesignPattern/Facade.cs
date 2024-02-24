/****************************************************
 *              디자인 패턴 Facade                  *
 ****************************************************/

/*
 * <퍼사드 패턴>
 * 복잡한 시스템을 간략한 서브 시스템으로 분리하여
 * 간단한 인터페이스를 제공하는 구성방법
 * 
 * <구현>
 * 1. 복잡한 시스템을 서브 시스템으로 분리하여 독립적인 기능을 구현
 * 2. 퍼사드 객체가 서브 시스템들을 포함
 * 3. 퍼사드 객체가 서브 시스템들을 동작시키기 위한 간단한 인터페이스를 구현
 * 
 * <장점>
 * 1. 복잡한 시스템에서 코드를 별도로 분리하여 구현할 수 있음
 * 2. 시스템의 특정 부분을 변경하더라도 전체 시스템에 미치는 영향이 적음
 * 3. 단일책임원칙을 준수함
 * 
 * <주의점>
 * 1. 서브 시스템의 세분화된 기능을 사용할 수는 없음
 * 2. 사용자에게 내부 서브 시스템을 숨길 수는 없음
 */


namespace DesignPattern
{
    public class Facade
    {
        private SubSystem1 subSystem1;
        private SubSystem2 subSystem2;
        private SubSystem3 subSystem3;

        public Facade(SubSystem1 subSystem1, SubSystem2 subSystem2, SubSystem3 subSystem3)
        {
            this.subSystem1 = subSystem1;
            this.subSystem2 = subSystem2;
            this.subSystem3 = subSystem3;
        }

        public void Operation()
        {
            subSystem1.Work();
            subSystem2.Active();
            subSystem3.SetUp();
        }
    }

    public class SubSystem1
    {
        public void Work() { }
    }

    public class SubSystem2
    {
        public void Active() { }
    }

    public class SubSystem3
    {
        public void SetUp() { }
    }
}

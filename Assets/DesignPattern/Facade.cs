/****************************************************
 *              ������ ���� Facade                  *
 ****************************************************/

/*
 * <�ۻ�� ����>
 * ������ �ý����� ������ ���� �ý������� �и��Ͽ�
 * ������ �������̽��� �����ϴ� �������
 * 
 * <����>
 * 1. ������ �ý����� ���� �ý������� �и��Ͽ� �������� ����� ����
 * 2. �ۻ�� ��ü�� ���� �ý��۵��� ����
 * 3. �ۻ�� ��ü�� ���� �ý��۵��� ���۽�Ű�� ���� ������ �������̽��� ����
 * 
 * <����>
 * 1. ������ �ý��ۿ��� �ڵ带 ������ �и��Ͽ� ������ �� ����
 * 2. �ý����� Ư�� �κ��� �����ϴ��� ��ü �ý��ۿ� ��ġ�� ������ ����
 * 3. ����å�ӿ�Ģ�� �ؼ���
 * 
 * <������>
 * 1. ���� �ý����� ����ȭ�� ����� ����� ���� ����
 * 2. ����ڿ��� ���� ���� �ý����� ���� ���� ����
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

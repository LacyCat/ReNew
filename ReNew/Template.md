# ���ø�
## 1. �̺�Ʈ�ڵ鷯 (����Ŭ����)
```csharp
# import ...
namespace ReNew.Events
{
	public class A 
	{
		private readonly bool debug;
		public A(Plugin<Configs> p) 
		{
			this.debug = p.Config.Debug;
		}
		# And Some Methods... (includes Register, Unregister)
	}
}
```
*����: ���� ��� ����Ǵ� �̺�Ʈ�̰�, ������ ����ġ ���� ��� �۵��� �� �ִ� �ڵ�� MEC�� CallDelayed�� ������ ����.*
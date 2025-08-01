# 템플릿
## 1. 이벤트핸들러 (개별클래스)
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
*주의: 만약 즉시 실행되는 이벤트이고, 로직이 예상치 못한 대로 작동할 수 있는 코드는 MEC의 CallDelayed를 쓰도록 하자.*
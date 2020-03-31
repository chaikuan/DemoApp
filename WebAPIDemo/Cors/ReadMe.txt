
一. 跨域  CorsTestController

1.启用允许跨域包（install-package Microsoft.AspNet.WebApi.Cors）
	a. 可以在NuGet 搜索 Cors 

2.支持跨域
	a.打开应用程序 Start/WebApiConfig.cs 将config.EnableCor(); 代码加入到 WebApiConfig.Register方法中。

3.配置那个控制器可以跨域  JwtTestController
	a.在控制器上加上EnableCors(origions:"http://www.example.com【哪个网站支持跨域】",headers:"*",methods:"*")特性
	b.若要操作禁用Cors,请添加DisableCors特性
	c.若要为应用程序中所有的WebAPI控制器中启用Cors,请将传递EnableCorsAttribute实例向EnableCors方法
		1.  var cors = new EnableCorsAttribute("www.example.com","*","*");
			config.EnableCors(cors);
			将这两行代码加入到WebApiCOnfig.Register方法中。


二. JWT 加密
	1.JWT由三块组成，可以把用户名、用户Id等保存到Payload部分
		a.第一块： Header 声明头
		b.第二块： Payload 键值对类型，存储的是加密的信息
		c.第三块： Signature 加密串
		注：Payload这部分信息是明文的所以不能保存让别人看到的机密信息，但是不用担心Payload被篡改，因为Signature部分是根据header+payload+secretKey进行加密算出来的，如果Payload被篡改，就可以根据Signature解密时候校验出来
	2.加密
		a.install-package jwt //需要.net4.6.2，旧版本要求低
		b. 新建一个控制台项目 JWTDemo 测试一下


三. 自带特性验证数据合法性  ValidTestController
	1.新建Student实体类 添加约束特性
	2.在ValidTestController 的action 中使用 ModelState.IsValid属性验证是否合法



四. 权限过滤

		
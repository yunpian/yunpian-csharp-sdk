yunpian-csharp-sdk
================================
[云片](https://www.yunpian.com/) SDK

## 快速开始

- nuget获取[yunpian-csharp-sdk](https://www.nuget.org/packages?q=Yunpian.Sdk)


- 示例YunpianClient

```csharp
//初始化clnt,使用单例方式
var clnt = new YunpianClient("apikey").Init();

//发送短信API
var param = new Dictionary<string, string>
            {
                [Const.Mobile] = "18616020***",
                [Const.Text] = "【云片网】您的验证码是1234"
            };
var r = clnt.Sms().SingleSend(param);
//获取返回结果, 返回码:r.Code, 返回码描述:r.Msg, API结果:r.Data, 其他说明:r.Detail, 调用异常:r.E

//账户:clnt.User().* 签名:clnt.Sign().* 模版:clnt.Tpl().* 短信:clnt.Sms().* 视频短信:clnt.VideoSms().* 语音:clnt.Voice().* 短链接:clnt.ShortUrl().*

//释放clnt
clnt.Dispose();
```

## 配置说明

- 自定义配置
	- 使用构造器 `new YunpianClient(string apikey,Dictionary<string, string> props)`
	- props内容参考YunpianConf

## 源码说明
- 工程源码
	- yunpian-csharp-sdk 云片SDK源码工程,`namespace=Yunpian.Sdk`
		- Api/ 云片接口源码
		- Model/ 模型对象定义
		- Util/ 工具类
		- YunpianClient 接口调用客户端
		- YunpianConf 客户端配置
	- yunpian-csharp-sdk-test 源码单元测试工程,`namespace=Yunpian.Sdk.Test`
		- Api/ 云片接口单元测试
- 开发API可参考单元测试
	- 在TestYunpianApi定义TestApikey,然后执行测试工程Api/里的单元测试
- YunpianClient使用单例方式，不要每次new
- 分支说明: master是发布版本,develop是待发布的分支(开源贡献可以pull request到develop)
## 环境要求

#### Windows
 - 需要`.NET 2.0` 及以上. 
 - 需要 `Visual Studio 2010`及以上.

#### Linux/Mac
 - 需要 `Mono 3.12` 及以上.

## 联系我们
[云片支持 QQ](https://static.meiqia.com/dist/standalone.html?eid=30951&groupid=0d20ab23ab4702939552b3f81978012f&metadata={"name":"github"})

SDK开源QQ群

<img src="doc/sdk_qq.jpeg" width="15%" alt="SDK开源QQ群"/>

## 文档链接
- [api文档](https://www.yunpian.com/api2.0/guide.html)


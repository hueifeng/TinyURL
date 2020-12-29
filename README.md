<div> 
<p align="center">
    <image src="TinyURL.png"  height="250">
 </p>
 <p align="center">一个简单、稳定、安全、快速的短链生成库。</p>
</div>


短码通过`[a - z, A - Z, 0 - 9]`这62个字符组成，短码长度一般不要超过8位。比较常用的都是6位，6位短码已有568亿种的组合：(26+26+10)^6=568002355884。

## 特性

- 灵活引用库，简单易用
- 持久化存储原始数据
- 采用自增ID和MurmurHash算法，无碰撞短码，安全可靠

## 快速入门

1、通过Nuget安装组件

```powershell
Install-Package TinyURL
```

2、获取短码

```csharp
TinyURL shortUrl = new TinyURL(
      new SqlServerStorageProcessor("Server=localhost;Database=TestDb;Trusted_Connection=True;"));
await shortUrl.Generator(url);
```

## 表结构

  <table> 
   <thead> 
    <tr> 
     <th>Table</th> 
     <th colspan="2">UrlDictionary</th> 
    </tr> 
    <tr> 
     <th>Name</th> 
     <th>Type</th> 
     <th>Details</th> 
    </tr> 
   </thead> 
   <tbody> 
    <tr> 
     <td>Id</td> 
     <td>[int] IDENTITY(1,1) NOT NULL</td> 
     <td>自增ID</td> 
    </tr> 
    <tr> 
     <td>Code</td> 
     <td>[nvarchar] (6)</td> 
     <td>短码</td> 
    </tr> 
    <tr> 
     <td>URL</td> 
     <td>[nvarchar] (128)</td> 
     <td>原链接</td> 
    </tr> 
    <tr> 
     <td>HashVal</td> 
     <td>[nvarchar] (32)</td> 
     <td>Hash Value</td> 
    </tr> 
    <tr> 
     <td>InsertAt</td> 
     <td>[datetime]</td> 
     <td>创建时间</td> 
    </tr> 
   </tbody> 
  </table>


## 贡献

如果您有想法可以加入进来，或者发现本项目中有需要改进的代码，欢迎Fork并提交PR！

## License

MIT

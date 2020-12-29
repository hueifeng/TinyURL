<div> 
<p align="center">
    <image src="TinyURL.png"  height="250">
 </p>
 <p align="center">一个简单、稳定、安全、快速的短链生成库。</p>
</div>

## 算法生成

短码通过`[a - z, A - Z, 0 - 9]`这62个字符组成，短码的长度可以自定义，但一般不要超过8位。比较常用的都是6位，
6位的短码已经能有568亿种的组合：(26+26+10)^6=568002355884。

对于`TinyUrl`采用了自增ID和MurmurHash算法的方式进行生成随机数，获取长URL的哈希值，
然后判断数据集是否存在哈希值对应的短码，如果有则直接返回；如果没有，将
URL、哈希值存入数据库中，并返回这条记录的ID值，这个值做为一个短码生成的一个依据。
将值生成哈希值在于对数据库查询效率。

然后将返回自增编码转换为61进制，将字母或者数字中的其中一个取出来作为连接符使用，这里
使用小写字母a，然后拼接到转换完的字符串后，不足六位的用随机字符补足，随机字符中也要将相应的链接符去除掉，
用以确保六位短码的唯一性。

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

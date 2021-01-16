<div> 
<p align="center">
    <image src="TinyURL.png"  height="250">
 </p>
 <p align="center">A simple, stable, safe, and fast short-chain generation library.</p>

<p align="center">
<a href="https://www.nuget.org/packages/TinyURL">
      <image src="https://img.shields.io/nuget/v/TinyURL.svg?style=flat-square" alt="nuget">
</a>
    
<a href="https://github.com/hueifeng/TinyURL/workflows/.NET%20Core/badge.svg">
      <image src="https://github.com/hueifeng/TinyURL/workflows/.NET%20Core/badge.svg" alt="NETCore">
</a>
    
<a href="https://www.nuget.org/stats/packages/TinyURL.Core?groupby=Version">
      <image src="https://img.shields.io/nuget/dt/TinyURL.Core.svg?style=flat-square" alt="stats">
</a>
    
<a href="https://raw.githubusercontent.com/hueifeng/TinyURL/master/LICENSE">
    <image src="https://img.shields.io/badge/license-MIT-blue.svg" alt="MIT">
</a>
</p>
</div>

## Description

Language: English | [中文](README.zh-cn.md)

The shortcode is composed of 62 characters of `[a-z, A-Z, 0-9]`, the length of the shortcode is 6 digits, and the 6-digit shortcode supports 56.8 billion combinations: (26+26+10)^6 =568002355884.

## Features

- Flexible reference library, easy to use
- Persistent storage of original data
- Self-increasing ID and MurmurHash algorithm are adopted to ensure the safety and reliability of shortcode without collision

## Quick Start

1、Install Package

```powershell
Install-Package TinyURL
```

2、Install the persistence library

```powershell
Install-Package TinyURL.SqlServer
```

3、Short code

```csharp
TinyURL shortUrl = new TinyURL(
      new SqlServerStorageProcessor("Server=localhost;Database=TestDb;Trusted_Connection=True;"));
await shortUrl.Generator(url);
```

## Table Structure

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
     <td>identity ID</td> 
    </tr> 
    <tr> 
     <td>Code</td> 
     <td>[nvarchar] (6)</td> 
     <td>short code</td> 
    </tr> 
    <tr> 
     <td>URL</td> 
     <td>[nvarchar] (128)</td> 
     <td>Original link</td> 
    </tr> 
    <tr> 
     <td>HashVal</td> 
     <td>[nvarchar] (32)</td> 
     <td>Hash Value</td> 
    </tr> 
    <tr> 
     <td>InsertAt</td> 
     <td>[datetime]</td> 
     <td>Creation time</td> 
    </tr> 
   </tbody> 
  </table>


## Contribution

If you have any ideas you can join in, or find that there is code in this project that needs improvement, welcome to Fork and submit a PR!

## License

[MIT](LICENSE)

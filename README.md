# Stimulsoft Reports.Web for .Net Core 7

Configuration Solution Net7Stimulsoft
<br/>
```
<Project Sdk="Microsoft.NET.Sdk.Web">
  <ItemGroup>
    <PackageReference Include="Stimulsoft.Reports.Web.NetCore" Version="2021.1.1" />
  </ItemGroup>
  <Target Name="PostBuild" AfterTargets="PostBuildEvent">
    <Exec Command="xcopy /y /d &quot;$(ProjectDir)Packages\*.*&quot; &quot;$(ProjectDir)$(OutDir)&quot;" />
  </Target>
</Project>
```

![Screenshot 2023-05-22 212021](https://github.com/fakhravari/Stimulsoft-Reports.Web-for-.Net-Core-7/assets/4311975/9d6cd248-1585-440b-b085-8e227a6f78c2)

![Screenshot 2023-05-22 211750](https://github.com/fakhravari/Stimulsoft-Reports.Web-for-.Net-Core-7/assets/4311975/f63516ad-ddef-4ca7-baeb-925ded13065b)

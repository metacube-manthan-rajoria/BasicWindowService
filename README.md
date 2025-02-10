# Basic Window Service

This is a basic Windows Background Service Application

Publish your Windows Service Application

```bash
dotnet publish -c Release -o ./publish
```

Register your service application to Services Control Manager

```bash
sc.exe create "[Write your service name here]" binpath="[Your Executable's Path]" 
```

Start your service

```bash
sc.exe start "[Your service name]"
```

> [!Note]
> The service name you give in `builder.Services` options will show up in `Event Viewer`

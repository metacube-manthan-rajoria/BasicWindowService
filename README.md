# Basic Window Service

This is a basic Windows Background Service Application

### How to Build

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

Use this test as temporary file

```text
wwp4nynQNB
R76H1yZF58
pTu4C66bbH
faj0CTcLTM
nVoqMejWbq
p4ZGA7nPx1
NJPrSqfJuA
hyfdkH1x4v
sKuXM23Loz
RP1WRTQh24
```
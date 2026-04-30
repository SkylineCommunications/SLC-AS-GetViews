# Technical Documentation Project

This project is specifically made for **Technical Documentation**, typically linked to the source code or package made available by the other projects in this solution. It uses [DocFX](https://dotnet.github.io/docfx/) to generate a static documentation website that can be deployed alongside your DataMiner package.

> [!NOTE]
> Only files inside the `Documentation` folder should typically be edited.

---

## Getting Started

### Prerequisites

- Install [DocFX](https://dotnet.github.io/docfx/) — follow the installation instructions in [Contributing to the DataMiner docs](https://docs.dataminer.services/CONTRIBUTING.html#installing-and-configuring-docfx).

### Building the Documentation

The DocFX build is configured as a **pre-build action** on the Documentation project. Simply building the project in your IDE will automatically generate the static documentation site.

The output is placed in the destination configured in `docfx.json`, which is typically:

```
PackageContent\CompanionFiles\Skyline DataMiner\Webpages\Public
```

### Previewing the Documentation Locally

To preview the documentation locally after building:

1. Open a **Developer PowerShell** in your IDE.
2. Navigate to the output folder:

   ```powershell
   cd "PackageContent\CompanionFiles\Skyline DataMiner\Webpages\Public"
   ```

3. Start the DocFX local web server:

   ```powershell
   docfx serve .\Documentation\
   ```

4. Open your browser and go to <http://localhost:8080/> to preview the site.

   > [!TIP]
   > If port 8080 is already in use, you can specify a different port:
   > ```powershell
   > docfx serve .\Documentation\ -p 8090
   > ```

---

## Contributing

Follow the best practices defined in the public DataMiner documentation:  
👉 [https://docs.dataminer.services/CONTRIBUTING.html](https://docs.dataminer.services/CONTRIBUTING.html)

---

## Documentation Workflow & Deployment

When a DataMiner package (containing this documentation) is deployed to a DataMiner system, the static documentation website becomes accessible directly via the DataMiner web server.

After deployment, you can navigate to the documentation using the following URL:

```
https://{DMA_IP}/public/Documentation/index.html
```

Replace `{DMA_IP}` with the IP address or hostname of your DataMiner Agent.

### Quick Access Tips

- **Bookmark** the URL above for easy access.
- **Low-Code App integration**: If you don't want to manually remember or type the URL, you can integrate this website in your Low-Code App in DataMiner that either:
  - **Opens a new tab** pointing to `https://{DMA_IP}/public/Documentation/index.html`, or
  - **Embeds the documentation** as a webpage component directly inside your app.
- **DataMiner Services**: If you want to expose a specific entry via [dataminer.services](https://dataminer.services), a Low-Code App with an embedded webpage component is a great option.
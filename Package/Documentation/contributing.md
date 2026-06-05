---
uid: contributing
---

# Contributing

Thank you for contributing to **SLC-AS-GetViews**. This page describes how to set up your development environment, work with the codebase, and submit changes.

## Repository

The source code is hosted on GitHub:
[https://github.com/SkylineCommunications/SLC-AS-GetViews](https://github.com/SkylineCommunications/SLC-AS-GetViews)

## Branching Convention

| Branch type | Naming pattern | Example |
|---|---|---|
| Feature or improvement | `Add-<description>` | `Add-Custom-Icon` |
| Bug fix | `Fix-<description>` | `Fix-Null-RecursionLevel` |
| Documentation | `Docs-<description>` | `Docs-Getting-Started` |

All work should be done on a dedicated branch. Do not commit directly to `main`.

## Setting Up Locally

### Prerequisites

- **Visual Studio** with the **DataMiner Integration Studio (DIS)** extension installed.
- .NET Framework 4.8 SDK.
- Access to a DataMiner Agent (DMA) for live testing.

### Steps

1. Clone the repository:

   ```bash
   git clone https://github.com/SkylineCommunications/SLC-AS-GetViews.git
   ```

2. Open `SLC-AS-GetViews.sln` in Visual Studio.
3. Build the solution (*Build* > *Build Solution*) to restore NuGet packages and verify there are no compilation errors.

## Testing Against a Live DMA

1. In Visual Studio, go to *Extensions* > *DIS* > *DMA* > *Connect* and select or add your DataMiner Agent.
2. Right-click the script project and choose *Publish Script* (or use *DIS* > *Publish*) to deploy the script to the connected DMA.
3. Open **DataMiner Cube**, navigate to *Apps* > *Automation*, and execute the script with your chosen parameters.
4. Verify the output in the *Information Events* log.

## Submitting a Pull Request

1. Make sure all changes compile without errors (`Build` > `Build Solution`).
2. Keep commits focused — one logical change per commit.
3. Write a clear PR description explaining *what* changed and *why*.
4. Reference any related GitHub issues in the PR description using `Closes #<issue-number>`.
5. Request a review from a project maintainer.

## Contributing to Documentation

Documentation lives in `Documentation\articles\`. Each article is a Markdown file with a docfx YAML front matter block:

```markdown
---
uid: your-article-uid
---

# Article Title
```

The `uid` must match the `topicUid` entry in `Documentation\articles\toc.yml`.

### Adding a New Article

1. Create a new `.md` file in `Documentation\articles\`.
2. Add the `uid` front matter.
3. Add a corresponding entry to `toc.yml`.

### Previewing Documentation Locally

If you have [docfx](https://dotnet.github.io/docfx/) installed:

```bash
cd Documentation
docfx docfx.json --serve
```

This builds the static site and serves it locally at `http://localhost:8080` so you can review your changes before pushing.
